'use strict';

/**
 * @ngdoc overview
 * @name configuratorApp
 * @description
 * # configuratorApp
 *
 * Main module of the application.
 */
angular
    .module('configuratorApp', [
        'ngAnimate',
        'ngCookies',
        'ngResource',
        'ngRoute',
        'ngSanitize',
        'ngTouch',
        'angular-loading-bar',
        'ngStorage',
        'angular-clipboard',
        'dndLists',
        'ui.bootstrap',
        'chart.js'
    ])
    .config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'views/main.html',
                controller: 'MainCtrl',
                controllerAs: 'main'
            })
            .when('/about', {
                templateUrl: 'views/about.html',
                controller: 'AboutCtrl',
                controllerAs: 'about'
            })
            .when('/change-password', {
                templateUrl: 'views/changePassword.html',
                controller: 'ChangePasswordCtrl',
                controllerAs: 'changepassword'
            })
            .when('/confirm-registration', {
                templateUrl: 'views/confirmRegistration.html',
                controller: 'ConfirmRegistrationCtrl',
                controllerAs: 'confirmregistration'
            })
            .when('/forgot-password', {
                templateUrl: 'views/forgotPassword.html',
                controller: 'ForgotPasswordCtrl',
                controllerAs: 'forgotPassword'
            })
            .when('/forgot-password-confirm', {
                templateUrl: 'views/forgotPasswordConfirm.html',
                controller: 'ForgotPasswordConfirmCtrl',
                controllerAs: 'forgotPasswordConfirm'
            })
            .when('/login', {
                templateUrl: 'views/login.html',
                controller: 'LoginCtrl',
                controllerAs: 'login'
            })
            .when('/profil', {
                templateUrl: 'views/profil.html',
                controller: 'ProfilCtrl',
                controllerAs: 'profil'
            })
            .when('/logout', {
                templateUrl: 'views/logout.html',
                controller: 'LogoutCtrl',
                controllerAs: 'logout'
            })
            .when('/registration', {
                templateUrl: 'views/registration.html',
                controller: 'RegistrationCtrl',
                controllerAs: 'registration'
            })
            .when('/projects/', {
                templateUrl: 'views/projectoverview.html',
                controller: 'ProjectOverviewCtrl',
                controllerAs: 'projectoverview'
            })
            .when('/projects/detail/:projectId', {
                templateUrl: 'views/projectdetail.html',
                controller: 'ProjectDetailCtrl',
                controllerAs: 'projectdetail'
            })
            .otherwise({
                redirectTo: '/'
            });
    }).run(function ($rootScope, $window, $sessionStorage,$route, $location) {
        $rootScope.ServiceUrl ="http://iaauth.azurewebsites.net/";
        //$rootScope.ServiceUrl = "http://localhost:53204/";

        $rootScope.isLoggedIn = false;
        if (typeof $sessionStorage.accessToken != 'undefined') {
            $rootScope.isLoggedIn = true;
        }

        $rootScope.genders = [
            {key: 'men', name: 'Männlich'},
            {key: 'women', name: 'Weiblich'}
        ];

        $rootScope.showAlert=function(showAlert){
            $rootScope[showAlert]=true;
            setTimeout(function(){ $rootScope[showAlert]=false; $route.reload();}, 4000);
        };

        $rootScope.hideAlert=function(hideAlert) {
            $rootScope[hideAlert] = false;
        };


        $rootScope.errorAlert= function(error){
            console.log(error);

            swal("Oops...", error.status+":"+error.statusText+" "+$rootScope.parseError(error.data), "error");
        };

        $rootScope.parseError=function (response) {
            var errortxt="";
            if(typeof response=="undefined" || response==null || typeof response.ModelState=="undefined" ){
                return "Unbekannter Fehler ist aufgetreten";
            }
            for (var key in response.ModelState) {
                for (var i = 0; i < response.ModelState[key].length; i++) {
                    errortxt+="\r\n"+response.ModelState[key][i];
                }
            }
            return errortxt;
        };
});
