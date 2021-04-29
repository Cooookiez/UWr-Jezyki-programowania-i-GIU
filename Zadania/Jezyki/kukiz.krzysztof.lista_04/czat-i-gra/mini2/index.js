var http = require('http');
var fs = require('fs');
var socket = require('socket.io');
var html = fs.readFileSync("index.html");

var rozmowa=["Witaj"]; 


//create a server object
var server=http.createServer(function (req, res) { // function to handle request
  res.write(html)
  res.end(); //end the response
}) 

var io = socket(server);

io.on('connection', function(socket) {
  // powstaje nowy socket z którym będziemy dadać z kolejnym klientem
  
  for(let msg of rozmowa)  
  socket.emit('chat message',msg); // wysyłamy dotychczasowy przebieg rozmowy;

  // ustawiamy sposób reakcji na otrzymywane wiadomości
  socket.on('chat message', function(msg) {
      rozmowa.push(msg)
      io.emit('chat message', msg); // do wszystkich
  })

});



server.listen(8080);
