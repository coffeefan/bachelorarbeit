'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.controller:LoginCtrl
 * @description
 * # LoginCtrl
 * Controller where the User can Login
 */
angular.module('configuratorApp')
    .controller('LoginCtrl', function ($scope, $rootScope, $sessionStorage,$http,$location)  {
        $rootScope.pageTitle="Login";
        //IF User already loged in go to dashboard
        if(typeof $sessionStorage.accessToken!= 'undefined') {
                $location.path("/dashboard");
        }

        $scope.requestLogin=function (){
            var data = {
                grant_type: 'password',
                username:   $scope.login.email,
                password: $scope.login.password
            };

            $http({
                method: 'POST',
                url: $rootScope.ServiceUrl+"token",
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded'
                },
                data: $.param(data)
            }).success(function (data) {
                $sessionStorage.accessToken=data.access_token;
                var userInfoRoute = $rootScope.ServiceUrl + 'api/Account/UserInfo';

                $http({
                    method: 'GET',
                    headers: {
                        Authorization: 'Bearer '+$sessionStorage.accessToken
                    },
                    url: userInfoRoute
                }).success(function (data) {
                    $rootScope.isLoggedIn = true;

                    $rootScope.user = data;
                    $sessionStorage.user=data;

                    //Reload AngularJS Application as a LoggedIn User
                    location.reload();

                }).error(function(data){
                    console.log("Error2");
                    console.log(data);
                    swal({
                        title: "Login",
                        text: data.error_description,
                        type: "error"
                    });
                });

            }).error(function(data){
                console.log("Error1");
                console.log(data);
                swal({
                    title: "Login",
                    text: data.error_description,
                    type: "error"
                });
            });
        };

    });