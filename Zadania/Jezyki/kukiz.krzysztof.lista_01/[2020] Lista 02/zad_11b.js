
function* liczbyPierwsze(n) {
    let _pierwsze = [];
    // lista wszystkich liczb od 1 do n
    for(let i = 2; i <= n; i++)
        _pierwsze.push(i)

    // usuwanie z tablicy liczb nie-pierwszych
    for(let i = 1; i < _pierwsze.length; i++) {
        let jestPiersza = true;
        for(let j = 0; j < i; j++) {
            if(_pierwsze[i] % _pierwsze[j] == 0) {
                jestPiersza = false;
                _pierwsze.splice(i, 1);
                i--;
                break;
            }
        }
        // jesli liczba pierwsza, yield
        if(jestPiersza) {
            yield _pierwsze[i]
        }
    }

}

for(liczbaPierwsza of liczbyPierwsze(100)) {
    console.log(liczbaPierwsza);
}