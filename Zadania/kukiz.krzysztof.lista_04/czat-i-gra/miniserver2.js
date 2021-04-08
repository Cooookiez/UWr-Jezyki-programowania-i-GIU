var http = require('http');

//create a server object:
http.createServer(function (req, res) { // function to handle request
  res.write('<h2>Hello World! </h2>')//write a response to the client
  res.write(Date()); 
  res.write('from the page '+req.url);
  res.end(); //endthe response
}).listen(8080); //the server object listens on port 8080

