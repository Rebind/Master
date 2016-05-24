﻿using UnityEngine;
using System.Collections;

public class OverWorld : MonoBehaviour {
    //private GameObject player;
    public LinkedList Levels;
    private GameObject tmpLevel;

    public float speed = 50f;

	public class Node {
        public Node next;
        public string left;
        public string right;
        public string up;
        public string down;
        public string level;
        public Vector3 position;
        public bool finished;
    }
    //LinkedList data structure to hold gameobjects and position
    public class LinkedList
    {
        private Node head;
        private Node last;
        private Node curr;
        //start a new node head
        public void addHead(string levelname, Vector3 position) {
            Node toAdd      = new Node();
            toAdd.level     = levelname;
            toAdd.position  = position;
            toAdd.finished  = false;
            toAdd.next      = null;
            toAdd.left      = null;
            toAdd.right     = null;
            toAdd.up        = null;
            toAdd.down      = null;
            curr        = toAdd;
            head        = toAdd;
            last        = toAdd;
        }
        //attach a new gameobject to the last element
        public void addNode(string levelname, string parent, string relativePosition, 
            Vector3 position) {
            Node toAdd      = new Node();
            toAdd.level     = levelname;
            toAdd.position  = position;
            toAdd.finished  = false;
            toAdd.next 	    = null;
           	toAdd.left 	    = null;
            toAdd.right     = null;
            toAdd.up 	    = null;
            toAdd.down 	    = null;

            if(head != null) {
            	last.next	= toAdd;
            	last 		= toAdd;

            	Node iter = head;
            	while(iter != null){
            		if(iter.level == parent) {
            			break;
            		} else {
            			iter = iter.next;
            		}
            	}
            	switch(relativePosition){
            		case "up":
            			iter.up 	= toAdd.level;
            			toAdd.down 	= iter.level;
            			break;
            		case "down":
            			iter.down 	= toAdd.level;
            			toAdd.up 	= iter.level;
            			break;
            		case "left":
            			iter.left 	= toAdd.level;
            			toAdd.right = iter.level;
            			break;
            		case "right":
            			iter.right 	= toAdd.level;
            			toAdd.left 	= iter.level;
            			break;
            		default:
            			break;
            	}
            }
        }
        //print all elements of list
        public void printall() {
        	Node iter = head;
        	while(iter != null){
        		Debug.Log(iter.level);
        		Debug.Log(iter.position);
        		Debug.Log(iter.left);
        		Debug.Log(iter.right);
        		Debug.Log(iter.up);
        		Debug.Log(iter.down);
        		iter = iter.next;
        	}
        }
        //find level
        public string findLevel(string level) {
        	string tmp = curr.level;
        	Node iter = head;
        	while(iter != null) {
        		if(iter.level == level) {
        			curr = iter;
        			tmp = iter.level;
        			return tmp;
        		} else {
        			iter = iter.next;
        		}
        	}
        	return tmp;
        }
        //move current node and get its position
        public string getNewPos(string direction) {
            string position = curr.level;
        	switch(direction) {
        		case "up":
        			if(curr.up != null) {
        				position = findLevel(curr.up);
        				return position;
        			} else {
        				return position;
        			}
        		case "down":
        			if(curr.down != null) {
                        position = findLevel(curr.down);
        				return position;
        			} else {
        				return position;
        			}
        		case "left":
        			if(curr.left != null) {
                        position = findLevel(curr.left);
        				return position;
        			} else {
        				return position;
        			}
        		case "right":
        			if(curr.right != null) {
                        position = findLevel(curr.right);
        				return position;
        			} else {
        				return position;
        			}
                case "none":
                    return position;
        	}
            return position;
        }
        //get the current level of the current node
        public string getCurr() {
            string tmp = null;
            if (curr != null){
                tmp = curr.level;
                return tmp;
            } else {
                return tmp;
            }
        }
    }

	// Use this for initialization
	void Start () {
        Levels = new LinkedList();
        //Put the levels here
        /*
        tmpLevel = GameObject.Find("BeggLevel");
        Levels.addHead(tmpLevel.name, tmpLevel.transform.position);

        tmpLevel = GameObject.Find("Showcase");
        Levels.addNode(tmpLevel.name, "BeggLevel", "left", tmpLevel.transform.position);

        tmpLevel = GameObject.Find("BlahBlah");
        Levels.addNode(tmpLevel.name, "BeggLevel", "right", tmpLevel.transform.position);

        tmpLevel = GameObject.Find("BlahBlahBlah");
        Levels.addNode(tmpLevel.name, "BeggLevel", "up", tmpLevel.transform.position);

        tmpLevel = GameObject.Find("BlahBlahBlahBlah");
        Levels.addNode(tmpLevel.name, "BeggLevel", "down", tmpLevel.transform.position);
        */

        tmpLevel = GameObject.Find("Level_1");
        Levels.addHead(tmpLevel.name, tmpLevel.transform.position);

        tmpLevel = GameObject.Find("Level_2");
        Levels.addNode(tmpLevel.name, "Level_1", "right", tmpLevel.transform.position);

        tmpLevel = GameObject.Find("Level_3");
        Levels.addNode(tmpLevel.name, "Level_2", "right", tmpLevel.transform.position);

        tmpLevel = GameObject.Find("Level_4");
        Levels.addNode(tmpLevel.name, "Level_3", "right", tmpLevel.transform.position);

        tmpLevel = GameObject.Find("Level_5");
        Levels.addNode(tmpLevel.name, "Level_4", "right", tmpLevel.transform.position);

        tmpLevel = GameObject.Find("Level_6");
        Levels.addNode(tmpLevel.name, "Level_5", "right", tmpLevel.transform.position);

        tmpLevel = GameObject.Find("Level_7");
        Levels.addNode(tmpLevel.name, "Level_6", "right", tmpLevel.transform.position);

        tmpLevel = GameObject.Find("Level_8");
        Levels.addNode(tmpLevel.name, "Level_7", "right", tmpLevel.transform.position);

        tmpLevel = GameObject.Find("Level_9");
        Levels.addNode(tmpLevel.name, "Level_8", "right", tmpLevel.transform.position);

        tmpLevel = GameObject.Find("Level_10");
        Levels.addNode(tmpLevel.name, "Level_9", "right", tmpLevel.transform.position);

        tmpLevel = GameObject.Find("Level_11");
        Levels.addNode(tmpLevel.name, "Level_10", "right", tmpLevel.transform.position);

        Levels.printall();
	}
	
	// Update is called once per frame
	void Update () {

	}
}