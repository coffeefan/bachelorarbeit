'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.controller:ForgotPasswordConfirmCtrl
 * @description
 * # ForgotPasswordConfirmCtrl
 * Controller where the User reset his Password after getting an E-Mail
 */
angular.module('configuratorApp')
    .controller('ForgotPasswordConfirmCtrl', function ($scope, $rootScope, $sessionStorage,$http,$location,$routeParams,ForgotPasswordConfirmService)  {
        $rootScope.pagetitle="Passwort neusetzen";

        $scope.reset=function(){
            ForgotPasswordConfirmService.confirmnewpassword({},{
                UserId:$routeParams.UserId,
                Token: $routeParams.Token,
                NewPassword:$scope.User.NewPassword,
                ConfirmPassword: $scope.User.ConfirmPassword
            },function (data) {
                swal({title: "Neues Passwort erfolgreich gesetzt", text: "", type: "success"}, function () {
                    $scope.$apply(function() { $location.path("/login"); });
                });
            },function (error) {
                $rootScope.errorAlert(error)
            });
        };

    });