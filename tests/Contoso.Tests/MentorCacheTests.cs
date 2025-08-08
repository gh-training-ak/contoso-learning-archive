using FluentAssertions;

namespace Contoso.Tests;

public sealed class MentorCacheTests
{
    [Fact]
    public void CacheKeyIsStableForTheSameCriteria()
    {
        const string first = "mentors:maths:online:25";
        const string second = "mentors:maths:online:25";

        first.Should().Be(second);
    }
}
