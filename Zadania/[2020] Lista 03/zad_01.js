
function bigger(b) {
    return function(a) {
        return a > b;
    }
}

x = [2, 32, 5, 3, 6];

console.log(x);
console.log(x.filter(bigger(3)));