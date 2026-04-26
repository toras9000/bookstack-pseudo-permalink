# BookStack Customize - Pseudo Permalink

It uses a [logical/visual theme system](https://www.bookstackapp.com/docs/admin/hacking-bookstack/) and redirection to achieve pseudo permalinks to each entity.  

BookStack has a standard [Page Permalinks](https://www.bookstackapp.com/docs/user/content-permalinks/), but this customization is different.  
For bookshelves, books, chapters, and pages, it displays a link to the entity's ID instead of the slug in the detail area .  

Specifically, it provides the following addresses that directly access entities.
- `/link/shelves/<id>`
- `/link/books/<id>`
- `/link/chapters/<id>`
- `/link/pages/<id>`

This is accomplished using redirects, which may not be very efficient as an access route.  
