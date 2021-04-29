var http = require('http');
var fs = require('fs');
var socket = require('socket.io');
var html = fs.readFileSync("index.html");
var i=0;
var rozmowa=["Witaj"]; 
var moves=[];
var td=[];
var last='';

//create a server object
var server=http.createServer(function (req, res) { // function to handle request
  res.write(html)
  res.end(); //end the response
}) 

var io = socket(server);

io.on('connection', function(socket) {
  // powstaje nowy socket z którym będziemy dadać z kolejnym klientem
  socket.id=i++;
  
  // wysyłamy dotychczasowy przebieg rozmowy
  socket.emit("id",socket.id)
  
  for(let msg of rozmowa)  
     socket.emit('chat message',msg); 

  for(let x of moves)  
     socket.emit('move',x); 

  // ustawiamy sposób reakcji na otrzymywane wiadomości
  socket.on('chat message', function(msg) {
      rozmowa.push(msg)
      io.emit('chat message', msg); // do wszystkich
  })

  // ustawiamy sposób reakcji na ruchy
  socket.on('move', function(msg) {
	  
	  let x=JSON.parse(msg)
	  if(td[x.pole]==undefined)
	  {
		  td[x.pole]=x.pionek;
		  moves.push(msg)
		  io.emit('move', msg); // do wszystkich
	  }
	  else
	  {
		  socket.emit('chat message',"Ruch niemożliwy: pole zajęte")
	  }
	  
  })
  
  socket.on('reset', function(msg) {
      rozmowa=[msg]
      moves=[]
      td=[]
      io.emit('reset', msg); // do wszystkich
  })

});



server.listen(8080);
