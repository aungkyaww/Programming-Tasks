function numInRangeFromArray (arr) {
  var num1, num2 = 0;
  var finalArr = [];
if (arr[0] > arr[1]) {
  num1 = arr[1];
  num2 = arr[0];
} 
else {
  num1 = arr[0];
  num2 = arr[1];
  
}
 // console.log(num1);
//  console.log(num2);
  
  for (var i = 0; i < num2-num1 + 1; i ++) {
   finalArr.push(num1 + i);
  }
//  console.log(finalArr);
  return finalArr;
}


function gcd(a, b) {
  var temp = 0;
  
  while (b != 0){
    temp = b;
    b = a % b;
    a = temp;
    
  }
  return a;
}

function lcm(a,b, arr){
  
  
  
  
  var lcm = a*b;
  lcm  = (lcm/gcd(a,b));
  //console.log(lcm);
  return lcm;
  
}


function smallestCommons(arr) {
 arr = numInRangeFromArray(arr);
  
  for (var i = 2; i < arr.length; i += 3) {
 //  lcm(arr[i], lcm(arr[i-1], arr[i-2]));
   
 }
var lcmm =  arr.reduce(function (acc, value) {
  return lcm(acc, value);
  
}); 
  
return lcmm;
}


smallestCommons([1,5]);

