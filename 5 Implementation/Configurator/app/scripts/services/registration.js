'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.service:RegistrationService
 * @description
 * # ForgotPasswordService
 * Service of the configuratorApp
 */


angular.module('configuratorApp').
factory('RegistrationService', function($resource,$rootScope){
    return $resource($rootScope.ServiceUrl+'api/Account/Register', {id:'@id'}, {
        'add': { method:'Post',isArray:false}
    });
});

