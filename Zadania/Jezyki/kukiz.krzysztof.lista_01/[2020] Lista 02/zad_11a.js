
function* dzielniki(n) {
    for(let i = 1; i <= n/2; i++) {
        if(n % i == 0) {
            yield i
        }
    }
    yield n
}

for(dzielnik of dzielniki(18)) {
    console.log(dzielnik);
}

