function *Fibonacci(){
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

let fib = Fibonacci()
for (let i = 0; i < 200; i++) {
    console.log(fib.next());
}