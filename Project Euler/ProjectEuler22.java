public class PE22 {

    /**
     * @param args the command line arguments
     */
    public static int calculateAlphaValue (String s) {
        String sUpper = s.toUpperCase();
        switch (sUpper) {
            case "A" : return 1;
            case "B" : return 2;
            case "C" : return 3;
            case "D" : return 4;
            case "E" : return 5;
            case "F" : return 6;
            case "G" : return 7;
            case "H" : return 8;
            case "I" : return 9;
            case "J" : return 10;
            case "K" : return 11;
            case "L" : return 12;
            case "M" : return 13;
            case "N" : return 14;
            case "O" : return 15;
            case "P" : return 16;
            case "Q" : return 17;
            case "R" : return 18;
            case "S" : return 19;
            case "T" : return 20;
            case "U" : return 21;
            case "V" : return 22;
            case "W" : return 23;
            case "X" : return 24;
            case "Y" : return 25;
            case "Z" : return 26;
        }
        return -1;
    }
    
    public static void main(String[] args) throws IOException {
        String[] strings = fileUtils.inputText("Path to "p022_names.txt", "\",\""); //https://projecteuler.net/problem=22
        Arrays.sort(strings);
        BigInteger total = new BigInteger("0");
        for (int i = 0; i < strings.length; i++) {
           String[] temp = strings[i].split("");
           int sum = 0;
            for (int j = 0; j < temp.length; j++) {
               sum += calculateAlphaValue(temp[j]);
            }
          total = total.add(BigInteger.valueOf((sum*i)));
           
        }
        System.out.println(total);
    }
    
}
