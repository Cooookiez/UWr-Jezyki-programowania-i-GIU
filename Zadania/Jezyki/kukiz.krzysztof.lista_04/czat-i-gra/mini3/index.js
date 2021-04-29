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
  // powstaje nowy socket z którym będziemy gadać z kolejnym klientem
  
  // wysyłamy dotychczasowy przebieg rozmowy
  for(let msg of rozmowa)  
     socket.emit('chat message',msg); 

  // ustawiamy sposób reakcji na otrzymywane wiadomości
  socket.on('chat message', function(msg) {
      rozmowa.push(msg)
      io.emit('chat message', msg); // do wszystkich
  })
  
  socket.on('reset', function(msg) {
      rozmowa=[msg]
      io.emit('reset', msg); // do wszystkich
  })

});



server.listen(8080);
