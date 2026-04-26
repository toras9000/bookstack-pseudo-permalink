@if (!$entity->draft)
    @php
             if ($entity->isA('bookshelf')) { $category = 'shelves';  }
        else if ($entity->isA('book'))      { $category = 'books';    }
        else if ($entity->isA('chapter'))   { $category = 'chapters'; }
        else if ($entity->isA('page'))      { $category = 'pages';    }
    @endphp
    @if (!empty($category))
        <a href="/link/{{ $category }}/{{ $entity->id }}" class="entity-meta-item">
            @icon('link')
            <div>
                Permalink
            </div>
        </a>
    @endif
@endif
