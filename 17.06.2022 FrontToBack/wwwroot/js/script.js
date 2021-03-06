$(document).ready(function () {

    // HEADER

    $(document).on('click', '#search', function () {
        $(this).next().toggle();
    })

    //search
    $(document).on("keyup", '#input-search', function () {
        let inputValue = $(this).val();
        $("#searchList li").slice(1).remove();
        $.ajax({
            url: "/home/SearchProduct?search=" + inputValue,
            method: "get",
            success: function (res) {
                $("#searchList").append(res);
            }
        });
    }),
        // basket

    $(document).on('click', '#mobile-navbar-close', function () {
        $(this).parent().removeClass("active");

    }),
    $(document).on('click', '#mobile-navbar-show', function () {
        $('.mobile-navbar').addClass("active");

    }),

    $(document).on('click', '.mobile-navbar ul li a', function () {
        if ($(this).children('i').hasClass('fa-caret-right')) {
            $(this).children('i').removeClass('fa-caret-right').addClass('fa-sort-down')
        }
        else {
            $(this).children('i').removeClass('fa-sort-down').addClass('fa-caret-right')
        }
        $(this).parent().next().slideToggle();
    }),


    // SLIDER

    $(document).ready(function () {
        $(".slider").owlCarousel(
            {
                items: 1,
                loop: true,
                autoplay: true
            }
        );
    });

    // PRODUCT

    $(document).on('click', '.categories', function(e)
    {
        e.preventDefault();
        $(this).next().next().slideToggle();
    })

    $(document).on('click', '.category li a', function (e) {
        e.preventDefault();
        let category = $(this).attr('data-id');
        let products = $('.product-item');
        
        products.each(function () {
            if(category == $(this).attr('data-id'))
            {
                $(this).parent().fadeIn();
            }
            else
            {
                $(this).parent().hide();
            }
        })
        if(category == 'all')
        {
            products.parent().fadeIn();
        }
    })

    //LoadMore 
    let skip = 2;
    let productCount = $('#productCount').val();
    let row = $("#productList");
    let row1 = $("#productList").children().last();

    let lastData = $(".lastData");
    let lastData1 = $(".lastData").html();

    $(document).on('click', '#loadMore', function () {
        let productList = $('#productList');
        $.ajax({
            url: "/product/loadMore?skip="+ skip,
            method: "get",
            success: function (res) {
                productList.append(res);
                skip += 2;
                    //if (skip > row[0].children.length) {
                    //    $("#loadMore").remove();
                //}
                if (skip >= productCount) {
                        $("#loadMore").remove();
                    }
            }
        })
    })

    //Basket 

    //let basketBtn = $('.prvntDflt')
    //$(document).on('click', basketBtn, function (ev) {
    //    ev.preventDefault();
    //})



    // ACCORDION 

    $(document).on('click', '.question', function()
    {   
       $(this).siblings('.question').children('i').removeClass('fa-minus').addClass('fa-plus');
       $(this).siblings('.answer').not($(this).next()).slideUp();
       $(this).children('i').toggleClass('fa-plus').toggleClass('fa-minus');
       $(this).next().slideToggle();
       $(this).siblings('.active').removeClass('active');
       $(this).toggleClass('active');
    })

    // TAB

    $(document).on('click', 'ul li', function()
    {   
        $(this).siblings('.active').removeClass('active');
        $(this).addClass('active');
        let dataId = $(this).attr('data-id');
        $(this).parent().next().children('p.active').removeClass('active');

        $(this).parent().next().children('p').each(function()
        {
            if(dataId == $(this).attr('data-id'))
            {
                $(this).addClass('active')
            }
        })
    })

    $(document).on('click', '.tab4 ul li', function()
    {   
        $(this).siblings('.active').removeClass('active');
        $(this).addClass('active');
        let dataId = $(this).attr('data-id');
        $(this).parent().parent().next().children().children('p.active').removeClass('active');

        $(this).parent().parent().next().children().children('p').each(function()
        {
            if(dataId == $(this).attr('data-id'))
            {
                $(this).addClass('active')
            }
        })
    })

    // INSTAGRAM

    $(document).ready(function(){
        $(".instagram").owlCarousel(
            {
                items: 4,
                loop: true,
                autoplay: true,
                responsive:{
                    0:{
                        items:1
                    },
                    576:{
                        items:2
                    },
                    768:{
                        items:3
                    },
                    992:{
                        items:4
                    }
                }
            }
        );
      });

      $(document).ready(function(){
        $(".say").owlCarousel(
            {
                items: 1,
                loop: true,
                autoplay: true
            }
        );
      });
})

let addBtn = document.querySelectorAll(".addBtn")
let totalCount = document.getElementById("totalCount")
let totalPrice = document.getElementById("totalPrice")
addBtn.forEach(add =>
    add.addEventListener("click", function () {
        let dataId = this.getAttribute("data-id")
        console.log(dataId)
        if () {

        }
        axios.post("/basket/AddItem?id="+dataId)
            .then(function (response) {
                // handle success
                totalCount.innerHTML = response.data.count
                totalPrice.innerHTML = ` $${response.data.price}`
                //console.log(response);
            })
            .catch(function (error) {
                // handle error
                console.log(error);
            })
    })
)

//let row = document.getElementById("productList")
//let lastData = document.getElementById("lastData");
//let prodName = document.querySelector(".prodName")

