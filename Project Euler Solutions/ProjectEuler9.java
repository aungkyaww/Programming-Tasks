public class ProjectEuler9 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
       
        int value = 1;
        int val1 = 0;
        int val2 = 0;
        int val3 = 0;
        for (int a = 1; a <= 998; a++) {
            for (int b = 1; b <= 999; b++) {
                for (int c = 1; c <= 1000; c++) {
                  value = (a*a)+(b*b)+(c*c);
                  //System.out.println(value);
                  if ((a + b + c == 1000) && (a*a + b*b == c*c)) {
                      val1 = a;
                      val2 = b;
                      val3 = c;
                      break;
                  }
                }
            }
        }
        System.out.print(val1 + " ");
        System.out.print(val2 + " ");
        System.out.println(val3 + " ");
        System.out.println(val1*val2*val3);
    }
    
}
