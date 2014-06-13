var app = angular.module("WebForum", [
'ngRoute'
])

app.config(function ($routeProvider) {
    $routeProvider
    .when('/', {
        templateUrl: 'Views/Home.html',
        controller: 'GlobalCtrl'
    })
    .when('/login', {
        templateUrl: 'Views/Login.html',
        controller: 'GlobalCtrl'
    })
    .when('/register', {
        templateUrl: 'Views/Register.html',
        controller: 'GlobalCtrl'
    })
    .when('/board/:id', {
        templateUrl: 'Views/Board.html',
        controller: 'GlobalCtrl'
    })
    .when('/board/:boardId/:id', {
        templateUrl: 'Views/Post.html',
        controller: 'GlobalCtrl'
    })
});