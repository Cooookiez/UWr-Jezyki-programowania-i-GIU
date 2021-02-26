
class Kolo {

    constructor(r) {
        this.r = r || 1;
    }

    get promien() {
        return this.r;
    }

    set promien(r) {
        this.r = r;
    }

    get srednica() {
        return this.r * 2;
    }

    set srednica(d) {
        this.r = d/2;
    }

    get pole() {
        return Math.PI * this.r * this.r;
    }

    set pole(p) {
        this.r = Math.sqrt(p / Math.PI);
    }

    get obwod() {
        return 2 * Math.PI * this.r;
    }

    set obwod(l) {
        this.r = l / 2 / Math.PI;
    }

}

console.log('r', 'd', 'p', 'l');

let k = new Kolo(3);
console.log(k.promien, k.srednica, k.pole, k.obwod);

k.promien = 8
console.log(k.promien, k.srednica, k.pole, k.obwod);

k.srednica = 10
console.log(k.promien, k.srednica, k.pole, k.obwod);

k.pole = 4
console.log(k.promien, k.srednica, k.pole, k.obwod);

k.obwod = 7
console.log(k.promien, k.srednica, k.pole, k.obwod);