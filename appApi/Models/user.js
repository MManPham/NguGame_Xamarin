  // module.exports = User;
  const mongoose = require('mongoose');
  const Schema = mongoose.Schema;
  
  //Create Shema and models 
  
  const user = new Schema({
    nameUser:String,
    score: Number,
    nameDivice:String,
  });
  
  const User = mongoose.model('User', user);
  
  module.exports = User;
  
  