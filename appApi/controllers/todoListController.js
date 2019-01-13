const Question = require("../models/question");
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