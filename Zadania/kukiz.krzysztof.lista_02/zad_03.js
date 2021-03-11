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

for (let x of fragment(Fibonacci(), 100, 3)) {
    console.log(x);
}