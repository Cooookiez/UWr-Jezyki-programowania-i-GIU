
function betweene(a, b) {
    return function(v) {
        return (v >= a && v <= b);
    }
}

x = [2, 32, 5, 3, 6];

console.log(x);
console.log(x.filter(betweene(2, 7)));