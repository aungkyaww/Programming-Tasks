public class ProjectEuler18 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws IOException {
        String filePath = "Path to "triangle.txt here"; //https://projecteuler.net/problem=18
     int[][] triangle = fileUtils.inputMatrix(filePath);
     
        for (int i = triangle.length - 2; i>= 0; i--) {
            System.out.println();
            for (int j = 0; j < triangle.length - 1; j++) {
             
             
            triangle[i][j] += Math.max(triangle[i + 1][j], triangle[i + 1][j+1]);
            //System.out.print(triangle[i][j] + " ");  
//            System.out.println();
//            System.out.println("triangle[" + i + "," + j + "]: " + triangle[i][j] );
           
            }
            
        }
        
        System.out.println(triangle[0][0]);
    }
    
}
