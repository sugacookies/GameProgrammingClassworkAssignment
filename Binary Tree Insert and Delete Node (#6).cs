class Node{
    public Node left;
    public Node right;
    int dataValue;
    
    public Node(int x){
        left = null;
        right = null;
        dataValue = x;
    }
    
    public static Node createBinaryTree(int[] arr, Node n, int index){
        if(index < arr.Length){
            Node temp = new Node(arr[index]);
            n = temp;
            
            n.left = createBinaryTree(arr, n.left, 2*index + 1);
            n.right = createBinaryTree(arr, n.right, 2*index + 2);
        }
        return n;
    }
    
    public static void insertNode(Node root, int value){
        Node newNode = newNode(value);
        Node tracker = root;
        Node insertNode = tracker;
        
        while(tracker != null){
            insertNode = tracker;
            if(value < tracker.dataValue){
                tracker = tracker.left;
            }
            else{
                tracker = tracker.right;
            }
        }
        
        if(insertNode == null){
            insertNode = newNode;
        }
        
        else if(value < insertNode.dataValue){
            insertNode.left = newNode;
        }
        
        else{
            insertNode.right = newNode;
        }
    }
        
    }
    
    public static void deleteNode(int value){
        Node tracker = root;
        Node deleteNode = tracker;
        
        while(tracker != null){
            deleteNode = tracker;
            if(value < tracker.dataValue){
                tracker = tracker.left;
            }
            else if(value = tracker.dataValue){
                deleteNode 
            }
            else{
                tracker = tracker.right;
            }
        }
        
        if(deleteNode == null){
            insertNode = newNode;
        }
        
        else if(value < insertNode.dataValue){
            insertNode.left = newNode;
        }
        
        else{
            insertNode.right = newNode;
        }
    }
    
    static void Main(){
    int[] arr = {16, 14, 10, 8, 7, 9, 3, 2, 4, 1}; //length 10
    Node start = new Node(arr[0]);
    createBinaryTree(arr, start, 0);
    
    }
    
    
}

