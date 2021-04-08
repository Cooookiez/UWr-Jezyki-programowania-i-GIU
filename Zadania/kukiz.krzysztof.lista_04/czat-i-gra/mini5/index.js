var http = require('http');
var fs = require('fs');
var socket = require('socket.io');
var html = fs.readFileSync("index.html");
var i=1;
var rozmowa=["Witaj"]; 
var moves=[];
var td=[];
var last=0;
var players=[];
var winner=undefined;

//create a server object
var server=http.createServer(function (req, res) { // function to handle request
  res.write(html)
  res.end(); //end the response
}) 

var io = socket(server);

io.on('connection', function(socket) {
  // powstaje nowy socket przez który będziemy gadać z kolejnym klientem
  socket.id=i++;
  
  // wysyłamy wartość nadanego id
  socket.emit("id",socket.id)
  
  // wysyłamy dotychczasowy przebieg rozmowy
  for(let msg of rozmowa)  
     socket.emit('chat message',msg); 

  for(let x of moves)  
     socket.emit('move',x); 

  // ustawiamy sposób reakcji na otrzymywane wiadomości
  socket.on('chat message', function(msg) {
      rozmowa.push(msg)             // zapamiętaj  
      io.emit('chat message', msg); // i wyślij do wszystkich
  })

  // ustawiamy sposób reakcji na ruchy
  socket.on('move', function(msg) {
	  
	let x=JSON.parse(msg)
	
	
	if(winner==undefined)
	{
	 
	   if(x.pionek!=players[0]&&x.pionek!=players[1])
	     if(players[0]==undefined)
	        players[0]=x.pionek;
	      else   	
	     if(players[1]==undefined)
	        players[1]=x.pionek;
	      else
		    socket.emit('chat message',"W tą grę graja "+players[0]+" oraz "+players[1]+". Twój id to "+socket.id+".")
	   
	  if(x.pionek==players[0] || x.pionek==players[1])        
		  if(last==x.pionek)
			  socket.emit('chat message',"Ruch niemożliwy: nie Twoja kolej")
		  else		
			  if(td[x.pole]==undefined)
			  {
				  last=td[x.pole]=x.pionek;
				  moves.push(msg)
				  io.emit('move', msg); // do wszystkich
				  if(winning_move(x))
				  {
					  winner=x.pionek;
					  io.emit('chat message',"Gra zakończona - wygrał "+winner+".");
				  }   
			  }
			  else
			  {
				  socket.emit('chat message',"Ruch niemożliwy: pole zajęte")
			  }
    }
    else
    {
		  socket.emit('chat message',"Ruch niemożliwy - gra zakończona.")		
		  socket.emit('chat message',"Naciśnij Przycisk 'Nowa gra' by zagrać od nowa.")		
	}
    
	  
  })
  
  socket.on('reset', function(msg) {
      rozmowa=[msg]
      moves=[]
      td=[]
      last=''
      winner=undefined;
      players=[]
      io.emit('reset', msg); // do wszystkich
  })

});


function winning_move(x)
{
	let n=12; // rozmiar wiersza szachownicy
	let left=0;
	let right=0;
	let i;
	for(let d of [1,n-1,n,n+1])
	{    
		let ile=1;
		i=x.pole;
		while(td[i-=d]==x.pionek)
		    ile++;
		i=x.pole;
		while(td[i+=d]==x.pionek)
		    ile++;
		if(ile>=5)
		{
			while(td[i-=d]==x.pionek)
			{   let y={pole:i,pionek:x.pionek,color:"yellow"};
				moves.push(JSON.stringify(y));
			    io.emit('move',JSON.stringify(y));
			}
			return true;
		}
	}
	return false;
}


server.listen(8080);
