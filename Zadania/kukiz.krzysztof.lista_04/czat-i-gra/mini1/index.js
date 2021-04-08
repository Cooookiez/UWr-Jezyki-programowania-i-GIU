var http = require('http');
var fs = require('fs');
var socket = require('socket.io');
var html = fs.readFileSync("index.html");




//create a server object:
var server=http.createServer(function (req, res) { // function to handle request
  res.write(html)//write a response to the client
  res.end(); //end the response
}) //the server object listens on port 8080


var io = socket(server);

io.on('connection', function(socket) {
  //console.log('client connected:' + socket.id);
  socket.emit('chat message','Witaj');

  socket.on('chat message', function(data) {
      io.emit('chat message', data); // do wszystkich
      //socket.emit('chat message', data); tylko do połączonego
  })

});




server.listen(8080);
