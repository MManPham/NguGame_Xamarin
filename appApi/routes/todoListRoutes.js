
  module.exports = (app) =>{
    var todoList =  require('../controllers/todoListController');


    app.route("/question")
        .get(todoList.getAllQuestion)
        .post(todoList.insertQuestion)  
        
        
    // app.route('/user')
    //    .get(Auth.verifyToken,todoList.list_User)
    //    .post(todoList.create_User);

    //   app.route('/userId/:user_id')
    //       .get(todoList.find_user_byId)
    //       .delete(todoList.delete_a_User)
    //       .put(todoList.update_User);
      
    //   app.route('/userName/:user_name').get(todoList.find_user_byName);

    //   app.route('/loginAdmin').post( todoList.loginAdmin);
    //   app.route('/registerAdmin').post(todoList.create_admin)
}