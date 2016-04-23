'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.controller:ForgotPasswordCtrl
 * @description
 * # ForgotPasswordCtrl
 * Controller where the User send a E-Mail for reseting his Password
 */
angular.module('configuratorApp')
    .controller('ForgotPasswordCtrl', function ($scope, $rootScope, $sessionStorage,$http,$location,ForgotPasswordService)  {
        $rootScope.pageTitle="";

        $scope.forgotSave=function(){
            ForgotPasswordService.forgot({},{Email:$scope.User.Email},function (data) {
                swal({title: "E-Mail wurde mit neuem Passwort gesendet", text: "", type: "success"}, function () {
                    $scope.$apply(function() { $location.path("/"); });
                });
            },function (error) {
                $rootScope.errorAlert(error)
            });
        };

    });