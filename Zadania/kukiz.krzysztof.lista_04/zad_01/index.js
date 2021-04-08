
const http = require("http");
const fs = require("fs")
const socket = require("socket.io");

var html = fs.readFileSync("index.html");

var server = http.createServer((req, res) => {
    // res.write("ala ma kota");
    console.log(req.url);
    // console.log(res);
    switch (req.url) {
        case '/':
            res.writeHead(200, {'Content-Type': 'text/html'});
            html = fs.readFileSync("index.html")
            break;
        case '/1':
        case '/1/':
            res.writeHead(200, {'Content-Type': 'text/html'});
            html = fs.readFileSync("1.html")
            break;
        case '/2':
        case '/2/':
            res.writeHead(200, {'Content-Type': 'text/html'});
            html = fs.readFileSync("2.html")
            break;
        case '/3':
        case '/3/':
            res.writeHead(200, {'Content-Type': 'text/html'});
            html = fs.readFileSync("3.html")
            break;
        case '/obraz.png':
            console.log("try");
            res.writeHead(200, {'Content-Type': 'image/png'});
            // b)
            html = fs.readFileSync("obraazek.png")
            // c)
            // html = fs.readFileAsync("obraazek.png");
            break;
        case '/l4.pdf':
            console.log("try");
            res.writeHead(200, {'Content-Type': 'document/pdf'});
            // b)
            html = fs.readFileSync("lista4.pdf")
            // c)
            // html = fs.readFileAsync("lista4.pdf");
            break;
        default:
            res.writeHead(200, {'Content-Type': 'text/html'});
            html = fs.readFileSync("404.html")
            break;
    }
    res.write(html)
    res.end();
});

server.listen(8080);

// var io = socket(server);
