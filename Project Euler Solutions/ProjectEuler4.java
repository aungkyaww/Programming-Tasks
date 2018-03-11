public class ProjectEuler4 {

   
      
    public static boolean palindrome(int num) {
        String number = Integer.toString(num);
        String[] numArr = new String[number.length()];
      
        numArr = number.split("");
       if (Arrays.equals(numArr, arrayUtils.reverseStringArray(numArr))) {
         
         return true;  
       }
      
      return false;
    }
    
    public static void main(String[] args) {
        int currentNum = 0;
     
        for (int i = 100; i < 1000; i++) {
            for (int j = 100; j < 1000; j++) {
                int num = j * i;
               
                if (palindrome(num) && num > currentNum) {
                    System.out.print((num + " "));
                    currentNum = num;
                }
            }
           
        }
    }

}
