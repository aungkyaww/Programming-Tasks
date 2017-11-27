public class ProjectEuler17 {

    /**
     *
     * @param num Only accepts values up to 9999
     * @return e.g 1045 --> one thousand and forty-five
     */
    public static String numberToWords (int num) {
        String finalStr = "";
        String one = "one";
        String and = "and";
        String two = "two";
        String three = "three";
        String four = "four";
        String five = "five";
        String six = "six";
        String seven = "seven";
        String eight = "eight";
        String nine = "nine";
        String ten = "ten";
        String eleven = "eleven";
        String twelve = "twelve";
        String thirteen = "thirteen";
        String fourteen = "fourteen";
        String fifteen = "fifteen";
        String sixteen = "sixteen";
        String seventeen = "seventeen";
        String eighteen = "eighteen";
        String nineteen = "nineteen";
        String twenty = "twenty";
        String thirty = "thirty";
        String dash = "-";
        String forty = "forty";
        String fifty = "fifty";
        String sixty = "sixty";
        String seventy = "seventy";
        String eighty = "eighty";
        String ninety = "ninety";
        String hundred = "hundred";
        String thousand = "thousand";
        
        if (num <= 20) {
            switch (num) {
                case 0: return "zero";
                case 1: return one;
                case 2: return two;
                case 3: return three;
                case 4: return four;
                case 5: return five;
                case 6: return six;
                case 7: return seven;
                case 8: return eight;
                case 9: return nine;
                case 10: return ten;
                case 11: return eleven;
                case 12: return twelve;
                case 13: return thirteen;
                case 14: return fourteen;
                case 15: return fifteen;
                case 16: return sixteen;
                case 17: return seventeen;
                case 18: return eighteen;
                case 19: return nineteen;
                case 20: return twenty;
            }
        }
        
        String workingVal = Integer.toString(num);
        if (num < 100) {
            //twenty + x etc;
            if (workingVal.charAt(1) == 0) {
                switch (workingVal.charAt(0)) {
                    case 3: return thirty;
                    case 4: return forty;
                    case 5: return fifty;
                    case 6: return sixty;
                    case 7: return seventy;
                }
            } 
        }
        
        
        
        return finalStr;
    }
    
    public static void main(String[] args) {
        // TODO code application logic here
    }
    
}
