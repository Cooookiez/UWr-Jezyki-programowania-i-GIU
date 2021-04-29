
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
        return BigInt( tmp );
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

function *fragment(iter, skip, limit=1) {
    let yields = 0;
    let v;
    while (yields < limit) {
        for (let i = 0; i < skip; i++) {
            iter.next();
        }
        yield iter.next();
        yields++;
    }
}

let fib1 = Fibonacci();
let fib2 = new Fibo();

for (let x of fragment(fib2, 100, 3)) {
    console.log(x);
}