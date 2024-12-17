using System.Collections.Generic;
using System.Collections;

namespace BehaviorTree {
    public enum NodeState {
        RUNNING,
        SUCCESS,
        FAILURE
    }
    public class Node {
        protected NodeState state;
        public Node parent;
        protected List<Node> children;
        public Node() {
            parent = null;
        }
        public Node(List<Node> children) {
            
        }
    }
}