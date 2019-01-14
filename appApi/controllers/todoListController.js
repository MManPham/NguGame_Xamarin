const Question = require("../models/question");
const User = require("../models/user");

const jwt = require('jsonwebtoken');


exports.getAllQuestion = (req, res)=>{
    Question.find({},(err,data)=>{
        if(err) res.send(err);
        else 
            res.json(data);
    });
}

exports.insertQuestion = (req,res)=>{
    Question(req.body).save((err,data)=>{
        if(err)throw err;
        res.json(data)
    })
}

///User
exports.getAllUser = (req, res)=>{
    User.find({},(err,data)=>{
        if(err) res.send(err);
        else 
            res.json(data);
    });
}

exports.insertUser = (req,res)=>{

    User(req.body).save((err,data)=>{
        if(err)throw err;
        res.json(data)
    })
}

exports.findUserByName = (req,res)=>{
    var id = req.params.user_id;
    User.find(
        {_id:id},(err,user) =>{
            if(err) throw err;
            else res.json(user);
        });
}

exports.findDevice = (req,res)=>{
    var nameDivice = req.params.user_device;
    User.find(
        {nameDivice:nameDivice},(err,user) =>{
            if(err) throw err;
            else res.json(user);
        });
}

exports.update_User = (req, res) =>{
    User.findOneAndUpdate({nameDivice: req.params.user_device}, req.body, {new: true},(err, user)=> {
        if (err)
          res.send(err);
        res.json(user);
      });
}
