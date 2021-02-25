
let f = (a, b) => a%100 - b%100;

let x = [1,2,3,271,12313,123,21313,541,42]

console.log(x);
x = x.sort(f);
console.log(x);