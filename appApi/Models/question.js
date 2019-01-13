  // module.exports = User;
  const mongoose = require('mongoose');
  const Schema = mongoose.Schema;
  
  //Create Shema and models 
  
  const question = new Schema({
    nameQuestion:String,
    rightAnswer: String,
    wrongAnswer1:String,
    wrongAnswer2:String,
    wrongAnswer3:String,
    author:String,
    explain:String,
  });
  
  const Question = mongoose.model('ngu_game', question);
  
  module.exports = Question;
  
  