'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.controller:RegistrationCtrl
 * @description
 * # RegistrationCtrl
 * Controller where the User can registrate himself
 */
angular.module('configuratorApp')
    .controller('ProjectOverviewCtrl', function ($scope, $rootScope,$location,ProjectService,$routeParams) {
        $rootScope.pageTitle = "Projektübersicht";

        $scope.loadProjects= function(){
            ProjectService.findAll({}, $scope.project, function (data) {

                $scope.projects=data;
            }, function (error) {
                $rootScope.errorAlert(error)
            });
        };


        $scope.loadProjects();

    });