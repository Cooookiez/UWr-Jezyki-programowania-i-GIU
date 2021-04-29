var http = require('http');
var fs = require('fs');
var socket = require('socket.io');
var html = fs.readFileSync("index.html");

var i=1;
var rozmowa=[]; 
var moves=[];
var td=[];
var last=0;
var players=[];
var sockets=[];
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

  socket.on('nick', function(nick) {
	socket.nick=nick;
	socket.emit('chat message', "Witaj "+nick+"!"); // i wyślij do wszystkich
})

  // ustawiamy sposób reakcji na ruchy
  socket.on('move', function(msg) {
	  
	let x=JSON.parse(msg)
	
	
	if(winner==undefined)
	{
	 
	   if(!players.includes(socket))
	     if(players[0]==undefined)
	        players[0]=socket;
	      else   	
	     if(players[1]==undefined)
	        players[1]=socket;
	      else
		    socket.emit('chat message',"Niestety "+info(socket)+". W tę grę grają "+info(players[0])+ " oraz "+info(players[1])+". Zaczekaj aż skończą.")
	   
	  if(players.includes(socket))        
		  if(last==x.pionek)
			  socket.emit('chat message',"Ruch niemożliwy: nie Twoja kolej")
		  else		
			  if(td[x.pole]==undefined)
			  {
				  last=td[x.pole]=x.pionek;
				  x.color= (players[0]==socket ? "green" : "blue")
				  msg=JSON.stringify(x);
				  moves.push(msg)
				  io.emit('move', msg); // do wszystkich
				  if(winning_move(x))
				  {
					  winner=socket;
					  let msg="Gra zakończona - wygrał "+info(winner)+".";
					  io.emit('chat message',msg);
					  rozmowa.push(msg);
				  }   
			  }
			  else
			  {
				  socket.emit('chat message',"Ruch niemożliwy: pole zajęte")
			  }
    }
    else
    {
		let msg="Gra zakończona - naciśnij 'Nowa gra' by zagrać.";
		socket.emit('chat message',msg);
		rozmowa.push(msg);
	}
    
	  
  })
  
  socket.on('reset', function(msg) {
      rozmowa=[];
      moves=[];
      td=[];
      last='';
      winner=undefined;
      players=[];
      io.emit('reset', msg); // do wszystkich
  })	

  socket.on("disconnect",function(msg)
  {	   
		if(players.includes(socket))
		{
			let [a,b]=players;
			winner= socket==a ? b : a;
			let msg=info(socket)+" się rozłączył. Gra przerwana. "+info(winner)+" wygrywa!";
			io.emit('chat message',msg);
			rozmowa.push(msg);
		}
   });
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
			{   let y={pole:i,pionek:x.pionek,color:"red"};
				moves.push(JSON.stringify(y));
			    io.emit('move',JSON.stringify(y));
			}
			return true;
		}
	}
	return false;
}


server.listen(8080);

function info(player)
{
	return player.nick+" ("+player.id+")";
}