using System.Collections.Generic;
using System.Linq;
using UnityEngine;

    public class Grapplinghook : MonoBehaviour
    {
		public AudioClip swoosh;
        public float Length = 4;
        public LayerMask mask = ~(1 << 9);
        WalkingScript ws;
        public bool IsEnabled
        {
            get { return _points.Any(); }
        }

        private readonly List<GameObject> _points = new List<GameObject>();
        private LineRenderer _line;
        private GameObject _grapple;
        private GameObject _previousGrapple;
        private float _previousDistance = -1;
        private DistanceJoint2D _joint;
		AudioSource playerAudio;

        void Start()
        {
            ws = GetComponent<WalkingScript>();
            _line = new GameObject("Line").AddComponent<LineRenderer>();
            _line.transform.position = new Vector3(0, 0, 1);
            _line.SetVertexCount(2);
            _line.SetWidth(.025f, .025f);
            _line.gameObject.SetActive(false);
            _line.SetColors(Color.black, Color.black);
            _line.GetComponent<Renderer>().material.color = Color.black;
            _line.GetComponent<Renderer>().material.shader = Shader.Find("Sprites/Default");
            _line.sortingLayerName = "Top";

        _grapple = new GameObject("Grapple");
            _grapple.AddComponent<CircleCollider2D>().radius = .1f;
            _grapple.AddComponent<Rigidbody2D>();
            _grapple.GetComponent<Rigidbody2D>().isKinematic = true;

            _previousGrapple = (GameObject)Instantiate(_grapple);
            _previousGrapple.name = "Previous Grapple";

            _joint = gameObject.AddComponent<DistanceJoint2D>();
            _joint.enabled = false;
			playerAudio = GetComponent<AudioSource> ();
        }

        void Update()
        {
        if (IsEnabled)
        {
            UpdateGrapple();
        }
        else CheckForGrapple();
        }

        private void CheckForGrapple()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePosition = Input.mousePosition;
                mousePosition.z = -Camera.main.transform.position.z;
                var worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                var grapplePoint = transform.position + (worldPosition - transform.position) * Length;

                var hit = Physics2D.Linecast(transform.position, grapplePoint, mask);
                var distance = Vector3.Distance(transform.position, hit.point);
                if (hit.collider != null && distance <= Length)
            {
                playerAudio.clip = swoosh;
                playerAudio.volume = 0.3f;
                playerAudio.Play();
                _line.SetVertexCount(2);
                    _line.SetPosition(0, hit.point);
                    _line.SetPosition(1, transform.position);
                    _line.gameObject.SetActive(true);
                    

                _points.Add(CreateGrapplePoint(hit));

                    _grapple.transform.position = hit.point;
                    SetParent(_grapple.transform, hit.collider.transform);

                    _joint.enabled = true;
                    _joint.connectedBody = _grapple.GetComponent<Rigidbody2D>();
                    _joint.distance = Vector3.Distance(hit.point, transform.position);
                    _joint.maxDistanceOnly = true;
                }
            }
        }

        private GameObject CreateGrapplePoint(RaycastHit2D hit)
        {
            var p = new GameObject("GrapplePoint");
            SetParent(p.transform, hit.collider.transform);
            p.transform.position = hit.point;
            return p;
        }

        private void UpdateGrapple()
        {
        ws.fallHeight = 0;
        UpdateLineDrawing();
            var hit = Physics2D.Linecast(transform.position, _grapple.transform.position, mask);
            var hitPrev = Physics2D.Linecast(transform.position, _previousGrapple.transform.position,mask);

            if (hit.collider.gameObject != _grapple && hit.collider.gameObject != _previousGrapple)
            {

                _points.Add(CreateGrapplePoint(hit));

                UpdateLineDrawing();

                _previousGrapple.transform.position = _grapple.transform.position;
                SetParent(_previousGrapple.transform, _grapple.transform.parent);
                _grapple.transform.position = hit.point;
                SetParent(_grapple.transform, hit.collider.transform);
                _previousDistance = -1;

                _joint.distance -= Vector3.Distance(_grapple.transform.position, _previousGrapple.transform.position);
            }
            else if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
            // if you retract the grappling hook
            ws.fallHeight = 0;
                // jump off
                if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < _grapple.transform.position.y)
                    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x /10, 3);

                RetractRope();
            }
            else if (Vector3.Distance(_grapple.transform.position, _previousGrapple.transform.position) <= .1f)
            {
                RemoveLastCollider();
            }
            else
            {
                // always update the last points in the line to track player

                _line.SetPosition(_points.Count, transform.position);
                GetComponent<Rigidbody2D>().AddForce(Vector3.right * Input.GetAxisRaw("Horizontal") * 2);
                _joint.distance -= Input.GetAxisRaw("Vertical") * Time.deltaTime;

                // if you can see previous point then unroll back to that point
                if (hitPrev.collider != null && hitPrev.transform == _previousGrapple.transform)
                    RemoveLastCollider();
            }

            UpdateDistance();
        }

        private void RetractRope()
        {
            _joint.enabled = false;
            _line.gameObject.SetActive(false);
            _points.ForEach(Destroy);
            _points.Clear();
            _grapple.transform.position = new Vector3(0, 0, -1);
            _previousGrapple.transform.position = new Vector3(0, 0, -1);
            _previousDistance = -1;
        }

        private void RemoveLastCollider()
        {
            if (_points.Count > 1)
            {
                Destroy(_points[_points.Count - 1]);
                _points.RemoveAt(_points.Count - 1);

                UpdateLineDrawing();

                _joint.distance += Vector3.Distance(_grapple.transform.position, _previousGrapple.transform.position);
                _grapple.transform.position = _previousGrapple.transform.position;
                SetParent(_grapple.transform, _previousGrapple.transform.parent);
            }

            if (_points.Count > 1)
                _previousGrapple.transform.position = _points.ElementAt(_points.Count - 2).transform.position;
            else
                _previousGrapple.transform.position = new Vector3(0, 0, -1);

            _previousDistance = -1;
        }

        private void UpdateLineDrawing()
        {
            _line.SetVertexCount(_points.Count + 1);
            for (var i = 0; i < _points.Count; i++)
                _line.SetPosition(i, _points[i].transform.position);
            _line.SetPosition(_points.Count, transform.position);
        }

        private void UpdateDistance()
        {
            if (_points.Count == 0) return;

            var distance = 0f;

            for (var i = 1; i < _points.Count; i++)
                distance += Vector3.Distance(_points[i - 1].transform.position, _points[i].transform.position);
            distance += Vector3.Distance(_points[_points.Count - 1].transform.position, transform.position);

            if (_previousDistance > 0)
                _joint.distance += _previousDistance - distance;

            _previousDistance = distance;

            if (distance > Length) RetractRope();
        }

        private void SetParent(Transform child, Transform parent)
        {
            child.SetParent(parent);
            if (parent != null)
                child.localScale = new Vector3(1 / parent.localScale.x, 1 / parent.localScale.y, 1 / parent.localScale.z);
        }
    }