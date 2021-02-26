
var suma = function() {
    let sum = 0;
    for (arg of arguments) {
        if (typeof arg == "number") {
            sum += arg
        }
    }
    return sum
}

let a = suma(1,2,3,10,"dad",20,"3",30)
console.log(a);