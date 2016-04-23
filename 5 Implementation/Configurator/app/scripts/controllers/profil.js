'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.controller:RegistrationCtrl
 * @description
 * # RegistrationCtrl
 * Controller where the User can registrate himself
 */
angular.module('configuratorApp')
    .controller('ProfilCtrl', function ($scope, $rootScope,$location,ProfilService) {
        $rootScope.pageTitle = "Registration";
        $scope.profil={};

        $scope.loadProfil= function(){
            ProfilService.loadit({}, {}, function (data) {
                $scope.profil=data;
            }, function (error) {
                $rootScope.errorAlert(error)
            });
        };

        $scope.update = function () {
            ProfilService.update({}, $scope.profil, function (data) {

                swal({title: "Updte erfolgreich", text: "Dein Profil wurde erfolgreich upgedatet", type: "success"});

            }, function (error) {
                $rootScope.errorAlert(error)
            });
        };

        $scope.loadProfil();


    });