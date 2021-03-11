
function *Fibonacci() {
    let i = 0;
    let sq5 = Math.sqrt(5);
    let tmp;
    while (true) {
        tmp = (((1 / sq5) * ((1 + sq5) / 2)**i) - ((1 / sq5) * ((1 - sq5) / 2)**i));
        tmp = Math.round(tmp);
        yield BigInt( tmp );
        i++;
    }
}
function Fibo() {
    this.i = 0;
}

Fibo.prototype[Symbol.iterator] = function *() {
    let sq5 = Math.sqrt(5);
    let tmp;
    while (true) {
        tmp = (((1 / sq5) * ((1 + sq5) / 2)**this.i) - ((1 / sq5) * ((1 - sq5) / 2)**this.i));
        tmp = Math.round(tmp);
        this.i++;
        yield BigInt( tmp );
    }
}

Fibo.prototype.next = function () {
    let sq5 = Math.sqrt(5);
    let tmp;
    tmp = (((1 / sq5) * ((1 + sq5) / 2)**this.i) - ((1 / sq5) * ((1 - sq5) / 2)**this.i));
    tmp = Math.round(tmp);
    tmp = BigInt(tmp)
    this.i++;
    return {value: tmp, done: false}
}

let fib1 = Fibonacci();
let fib2 = Fibo();
for (let i = 0; i < 200; i++) {
    console.log(fib1.next());
    console.log(fib2.next());
    console.log();
}