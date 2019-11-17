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
    
    static void Main(){
    int[] arr = {16, 14, 10, 8, 7, 9, 3, 2, 4, 1}; //length 10
    Node start = new Node(arr[0]);
    createBinaryTree(arr, start, 0);
    }
}

