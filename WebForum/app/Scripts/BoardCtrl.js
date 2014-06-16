app.controller("BoardCtrl", function ($scope, $http, $location, $routeParams) {
    $scope.getBoards = function () {
        $http({ method: 'GET', url: '/api/v1/Board/' })
        .success(function (data) {
            $scope.Boards = data;
        })
    }

    $scope.GetBoard = function () {
        $http({ method: 'GET', url: '/api/v1/Board/' + $routeParams.id })
        .success(function (data) {
            $scope.Board = data;
        })
    }

    $scope.GoToBoard = function (id) {
        $location.path('/board/' + id);
    }

    $scope.AddPost = function () {
        $http({ method: "POST", url: '/api/v1/Post/', data: $scope.Post })
               .success(function (data) {
                   alert("You have just created a post! :-)  " + $scope.Post.Title);
                   $scope.GetBoard();
                   document.getElementById("postTitle").value = "";
                   document.getElementById("postBody").value = "";

               });
    }

    $scope.GoToPost = function (id) {
        $location.path('/board/' + $routeParams.id + '/' + id);
    }
    $scope.GoToUpdate = function (id) {
        $location.path('/UpdatePost/' + id);

    }
    $scope.DeletePost = function (id) {
        $http({ method: "DELETE", url: '/api/v1/Post/' + id, data: id })
        .success(function (data) {
            alert("You have just deleted a post! :-(  " + $scope.Post.Title);
            $scope.GetBoard();
        });
    }
})