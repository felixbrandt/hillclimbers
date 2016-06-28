using System.Collections.Generic;
using System.Linq;
using UnityEngine;
    public class Climbing : MonoBehaviour
    {
        public float Speed = 5;
        public float JumpForce = 20;
        WalkingScript ws;

    public bool IsOnRope = false;
        private readonly List<GameObject> _ropeSegments = new List<GameObject>();

        private GameObject _prevTop;

        private GameObject _moveTowardsCenter;


        void Start()
        {
            ws = GetComponent<WalkingScript>();
        }
        void Update()
        {
            if (IsOnRope)
            {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<ItemController>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            GetComponent<WalkingScript>().enabled = false;
            // Jump off rope
            if (IsOnRope && Input.GetKeyDown(KeyCode.Space))
                {
                ws.fallHeight = 0;
                GetComponent<Rigidbody2D>().gravityScale = 1;
                GetComponent<ItemController>().enabled = true;
                GetComponent<PlayerAttack>().enabled = true;
                GetComponent<WalkingScript>().enabled = true;
                IsOnRope = false;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce));
            }

            // Grab the middle rope segment player collides with since this would be closest to player's center
            GameObject top = null;

                if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0 || _prevTop == null)
                {
                    var all = _ropeSegments.OrderByDescending(x => x.transform.position.y);
                    if (all.Any()) top = _ropeSegments[_ropeSegments.Count - 1];
                }
                else
                {
                    top = _prevTop;
                }

                if (top != null)
                {

                    // Climb rope
                    GetComponent<Rigidbody2D>().velocity = top.GetComponent<Rigidbody2D>().velocity + 
                        new Vector2(top.transform.up.x,Input.GetAxisRaw("Vertical")*Speed*top.transform.up.y);

                }

                // Move towards middle of rope if you've somehow moved off of it
                if (_moveTowardsCenter != null)
                {
                    transform.position = Vector3.MoveTowards(transform.position,
                        _moveTowardsCenter.transform.position - _moveTowardsCenter.transform.up*.24f, .1f);

                    if (Vector3.Distance(transform.position, _moveTowardsCenter.transform.position) < .2f)
                        _moveTowardsCenter = null;
                }
            }
        }




        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag == "Rope")
            {
                if (_ropeSegments.Count() == 1 && col.gameObject != _moveTowardsCenter)
                {
                    _moveTowardsCenter = null;
                    _ropeSegments.Add(col.gameObject);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.tag == "Rope")
            {
                _ropeSegments.Remove(col.gameObject);
            }
        }

        private void OnTriggerStay2D(Collider2D col)
        {
            if ((IsOnRope || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && col.tag == "Rope")
            {
                IsOnRope = true;
                if (!_ropeSegments.Contains(col.gameObject))
                    _ropeSegments.Add(col.gameObject);
            }
        }

    }