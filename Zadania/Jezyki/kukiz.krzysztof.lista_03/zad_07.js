
let dokument = "Ala ma kota, Kot widzi ale.";

console.log(dokument);

dokument = dokument.split(' ')

for(i = 0; i < dokument.length; i++) {
    let tmp = "";
    for (j = 0; j < dokument[i].length; j++) {
        let ch = dokument[i][j];
        switch (ch) {
            case '.':
            case ',':
            case '?':
            case '!':
                tmp += ch;
                break;
            default:
                tmp = ch + tmp;
                break;
        }
    }
    dokument[i] = tmp;
}

dokument = dokument.join(" ");

console.log(dokument);