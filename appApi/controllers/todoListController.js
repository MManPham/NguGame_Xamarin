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
    var user = req.params.user_name;
    User.find(
        {nameUser:user},(err,user) =>{
            if(err) throw err;
            else res.json(user);
        });
}

