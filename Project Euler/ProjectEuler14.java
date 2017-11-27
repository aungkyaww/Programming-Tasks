public class ProjectEuler14 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        //Collatz Sequence
        long len = 0;
        long num = 10;
        long finalNum = 0;
        
       // ArrayList<Long> sequence = new ArrayList<>();
        
        for (int i = 10; i < 1000000; i++) {
            ArrayList<Long> sequence = new ArrayList<>();
            num = i;
            sequence.add(num);
            while (num != 1) {
           
          if ((num & 1) == 0) {
                //even
                num = (num/2);
                //System.out.print(num + " ");
                sequence.add(num);
            }
            else
            {
                //odd
                num = (3*num) + 1;
                sequence.add(num);
            }
        }
           if (sequence.size() > len) {
                //System.out.print(":" + len + " " + finalNum);
               len  = sequence.size();
               finalNum = i;
           } 
        }
         
        
             System.out.print(len + " " + finalNum);
             
    }
    
    public static ArrayList<Long> collatz(int num) {
        ArrayList<Long> sequence = new ArrayList<>();
        long number = Long.valueOf(num);
        if (num <= 1) {
            sequence.add(number);
           return sequence;
        }
         sequence.add(number);
        while (num != 1) {
           
          if ((num & 1) == 0) {
                //even
                num = (num/2);
                System.out.print(num + " ");
                sequence.add(number);
            }
            else
            {
                //odd
                num = (3*num) + 1;
                sequence.add(number);
            }
        }
        
      
      System.out.println();
      System.out.println();
      
      return sequence;
      
    }
    
}
