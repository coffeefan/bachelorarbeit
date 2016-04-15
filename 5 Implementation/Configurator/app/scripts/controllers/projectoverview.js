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

        $scope.deleteProject= function(projectId){

            swal({
                title: "Löschen von Projekt "+projectId,
                text: "Willst du wirklich das Projekt löschen?",
                type: "warning",
                showCancelButton: true,
                closeOnConfirm: false,
                showLoaderOnConfirm: true
            },
                function(){
                    $scope.deleteProjectNow(projectId);
            });
        };

        $scope.deleteProjectNow=function(projectId){
            ProjectService.remove({id:projectId}, {}, function (data) {
                swal({title: "Löschung erfolgreich", text: "Das Projekt wurde erfolgreich gelöscht", type: "success"}, function () {
                    location.reload();
                });
            }, function (error) {
                $rootScope.errorAlert(error)
            });
        };


        $scope.loadProjects();

    });