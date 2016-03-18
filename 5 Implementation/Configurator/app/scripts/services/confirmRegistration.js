'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.service:ConfirmRegistrationService
 * @description
 * # ConfirmRegistrationService
 * Service of the configuratorApp
 */

'use strict';

angular.module('configuratorApp').
factory('ConfirmRegistrationService', function($resource,$rootScope,$sessionStorage){
    return $resource($rootScope.ServiceUrl+'api/Account/ConfirmEMail?UserId=:UserId&Code=:Code', {
        user:'@userid',
        code:'@code'}, {
        'confirm': { method:'POST' }
    });
});