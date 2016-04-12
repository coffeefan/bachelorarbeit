/*
 * 
 * 
 *
 * Copyright (c) 2016 Chris Bachmann
 * Licensed under the MIT license.
 */
var Datatrans = new function () {

  var scrollingLockStyle = document.createElement("style");
  scrollingLockStyle.innerHTML = "html.datatransPaymentHostLocked {" +
      " width: 100%; height: 100%; overflow: hidden; }" +
      " html.datatransPaymentHostLocked body { " +
      "width: 100%; height: 100%; overflow: visible; position: fixed; }";

  document.getElementsByTagName('head')[0].appendChild(scrollingLockStyle);

  var paymentFrame;

  this.startPayment = function (config)
  {
    toggleLockHostpage();

    if(config.opened instanceof Function)
    {
      config.opened();
    }

    jQuery(config.form).submit(function(e){
      e.preventDefault();
    });

    var params = {};

    jQuery.each(jQuery(config.form).data(), function (k, v) {
      params[k] = v;
    });

    params['theme'] = 'DT2015';
    params['version'] = datatransPaymentConfig.version;

    var action = datatransPaymentConfig.endpoint;

    var paymentForm = jQuery("<form/>").attr("id","datatransPaymentForm").attr("method","post").css("display","none");

    paymentForm.attr( { "action": action, "target": "datatransPaymentFrame"} );
    for ( var name in params )
    {
      if ( name == "paymentmethod" )
      {
        var paymentMethod = params[name];
        if ( paymentMethod == "")
          continue;
        if ( paymentMethod.indexOf(",") >=0 )
        {
          var paymentMethods = paymentMethod.split(",");
          jQuery.each( paymentMethods, function( index, value ) {
            paymentForm.append(jQuery("<input/>").attr({"type": "hidden", "name": name }).val(value));
          });
          continue;
        }
      }

      paymentForm.append(jQuery("<input/>").attr({"type": "hidden", "name": name }).val(params[name]));
    }

    paymentForm.append( jQuery("<input/>").attr( {"type": "hidden", "name": "uppReturnTarget" } ).val( "_top" ) );

    paymentFrame = jQuery("<iframe/>")
        .css( {
          "border": 0, "margin": 0, "padding": 0,
          "width": "100%", "height": "100%",
          "-webkit-transform": "translate3d(0, 0, 0)"
        } )
        .attr( {
          "id": "datatransPaymentFrame",
          "name": "datatransPaymentFrame",
          "frameborder": 0, "allowtransparency": "true"
        } );

    var paymentFrameWrapper = jQuery("<div/>").css( {
          "z-index": 9999,
          "position": "fixed",
          "right": 0,
          "bottom": 0,
          "left": 0,
          "top": 0,
          "overflow": "hidden",
          "-webkit-transform": "translate3d(0, 0, 0)"
        }
    );

    paymentFrame = paymentFrameWrapper.append( paymentFrame );
    paymentFrame.hide();

    paymentForm.append( jQuery("<input/>").attr( {"type": "hidden", "name": "mode" } ).val( "lightbox" ) );
    jQuery("body").append(paymentFrame).append(paymentForm)


    if (window.addEventListener) {
      window.addEventListener('message', windowEventHandler);
    } else if (window.attachEvent)  {
      window.attachEvent('message', windowEventHandler);
    }

    function windowEventHandler(event) {
      /*if (event.origin !== datatransPaymentConfig.endpoint)
        return;
      */
      if (event.data == "cancel") {
        paymentForm.remove();
        paymentFrame.remove();
        if (config.closed instanceof Function) {
          config.closed();
        }
        toggleLockHostpage(false);
      }
      if (event.data == "frameReady") {
        if (config.loaded instanceof Function) {
          config.loaded();
        }
        paymentFrame.show();
      }
    }

    paymentForm.submit()
  };

  function toggleLockHostpage(doActivate) {
    var html = jQuery('html');
    var body = jQuery('body');
    var doActivate = (doActivate == null ? (html.hasClass('datatransPaymentHostLocked') ? false : true) : !!doActivate);
    var scrollPos;

    if(doActivate) {
      scrollPos = body.scrollTop();

      html.addClass('datatransPaymentHostLocked');
      body.css('top', (scrollPos * -1));
    } else {
      scrollPos = (parseInt(body.css('top'), 10) * -1);

      html.removeClass('datatransPaymentHostLocked');
      body
          .scrollTop(scrollPos)
          .css('top', '');
    }
  }

};


var datatransPaymentConfig = {"endpoint":"http://www.christianbachmann.ch/testpage.php","version":"1.0.0"};

