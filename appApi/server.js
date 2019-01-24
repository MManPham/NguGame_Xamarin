const express = require('express');
const mongoose = require("mongoose");

const cors = require('cors')
const bodyParser = require('body-parser');
const  app = express();
const http = require('http')
const server = http.createServer(app)


//use
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

mongoose.connect('mongodb://ngugame121:ngugame121@ds259410.mlab.com:59410/ngu_game',{ useNewUrlParser: true });

mongoose.connection.once('open',function(){
    console.log('connnect has be make');
    }).on('err', function (err) {
    console.log('connect error',err);
})  


var routes = require('./routes/todoListRoutes'); //importing route
routes(app); //register the route

server.listen(process.env.port ||3000,'192.168.100.41',()=>{
    console.log('Server is running');
    
});

