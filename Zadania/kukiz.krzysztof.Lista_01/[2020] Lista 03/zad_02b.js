
let suma = function() {
    let sum = 0;
    for (arg of arguments) {
        if (typeof arg == "number") {
            sum += arg;
        }
        else if (Array.isArray(arg)) {
            sum += suma(...arg);
        }
    }
    return sum
}

let a = suma(1,2,3,[4,5,"aa"],10,"asda")
console.log("25 vs " + a);